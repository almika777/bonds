using System.Text;
using Telegram.BotAPI.AvailableTypes;

namespace Bonds.Telegram.Commands
{
    public class StartMessageCommand : IMessageCommandHandler
    {
        public Task<Message> Handle(Message message)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Привет {message.From.FirstName}, я бот для получения информации по облигациям");
            sb.AppendLine("");
            sb.AppendLine("Чтобы получить информацию, отправь ISIN Облигации");
            sb.AppendLine("Обратным сообщением ты увидишь:");
            sb.AppendLine(" - Имя эмитента");
            sb.AppendLine(" - ISIN");
            sb.AppendLine(" - Доходность");
            sb.AppendLine(" - Текущая цена (%)");
            sb.AppendLine(" - Купон (%)");
            sb.AppendLine(" - Изменение за день (%)");
            sb.AppendLine(" - Дней до погашения или оферты");
            sb.AppendLine(" - Флоатер ли бумага");
            sb.AppendLine(" - Время, на которое данные акктуальный");
            sb.AppendLine(" - Другие бумаги эмитента с базовыми показателями");
            sb.AppendLine("");
            sb.AppendLine("В результате ISIN бумаги, который был введен, будет кликабельным (откроется ссылка на Мосбиржу)");
            sb.AppendLine("");
            sb.AppendLine("ISIN других бумаг эмитента тоже кликабельна (хоть это и не видно на некоторых устройствах). " +
                          "При нажатии на него оно скопируется в буфер обмена и можно будет сразу вставить его в чат");
            sb.AppendLine("");
            sb.AppendLine("Через какое-то время планирую сделать ежемесячную плату за бота (не большую), а пока он полностью бесплатен");
            sb.AppendLine("");
            sb.AppendLine("Для обратной связи можете писать мне: <a href=\"tg://user?id=285783010\">Альмир</a>");

            return Task.FromResult(new Message
            {
                Text = sb.ToString()
            });
        }
    }
}
