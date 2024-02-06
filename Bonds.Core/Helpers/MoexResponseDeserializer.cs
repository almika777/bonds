using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Bonds.Core.Helpers
{
    public class MoexResponseDeserializer
    {
        public static List<T> Deserialize<T>(string? response)
        {
            var objectResponse = JsonSerializer.Deserialize<Dictionary<string, object>>(response);
            var type = typeof(T);
            var properties = type.GetProperties();
            var columns = objectResponse["columns"].ToString()?.Split(',').ToList();
            var datas = JsonSerializer.Deserialize<List<object>>(objectResponse["data"].ToString());

            return datas.Select(x =>
            {
                var entity = Activator.CreateInstance<T>();

                var splitedData = x.ToString().Split(',');
                foreach (var propertyInfo in properties)
                {
                    var responsePropertyName = propertyInfo.CustomAttributes
                        .FirstOrDefault(x => x.AttributeType == typeof(JsonPropertyNameAttribute))
                        ?.ConstructorArguments.First().Value as string;

                    var column = columns?.FirstOrDefault(x => x.Contains(responsePropertyName));
                    var columnIndex = columns.IndexOf(column);
                    var stringValue = splitedData[columnIndex].Trim();
                    var convertType = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;
                    var value = GetValue(stringValue, convertType);

                    propertyInfo.SetValue(entity, value);
                }

                return entity;
            }).ToList();
        }

        private static object? GetValue(string stringValue, Type convertType)
        {
            if (string.IsNullOrEmpty(stringValue) || stringValue.Equals("null"))
                return null;

            stringValue = stringValue.Replace("\"", "");
            try
            {
                return convertType switch
                {
                    not null when convertType == typeof(string) => stringValue,
                    not null when convertType == typeof(double) => Convert.ToDouble(stringValue.Replace(".", ",")),
                    not null when convertType == typeof(int) => Convert.ToInt32(stringValue),
                    not null when convertType == typeof(long) => Convert.ToInt64(stringValue),
                    not null when convertType == typeof(bool) => stringValue.Equals("A"),
                    not null when convertType == typeof(DateTime) => GetDate(stringValue),
                    _ => throw new Exception()
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


            object? GetDate(string stringValue)
                => DateTime.TryParseExact(stringValue, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var date)
                    ? date
                    : null;
        }
    }
}
