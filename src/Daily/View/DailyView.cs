using Daily.Entities;
using Flunt.Notifications;
using Flunt.Validations;

namespace Daily.View
{
    public class DailyView : Notifiable<Notification>
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public DailyAnnotation MapTo()
        {

            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNotNull(Title, "Informe o titulo da daily de hoje!")
                .IsGreaterThan(Title, 5, "O titulo da daily deve conter mais de 5 caracteres")
                .IsNotNull(Description, "Informe qual é a produção")
                .IsGreaterThan(Title, 5, "O titulo da daily deve conter mais de 5 caracteres"));

            return new DailyAnnotation(Guid.NewGuid(), Title, Description, false);
        }

    }
}
