using Projektuppgift_GIK2JK_Grupp11;

namespace Projektuppgift_GIK2JK_Grupp11
{
    public class Booking
    {
        public DateTime PlanedTime { get; set; }
        public Costumers Costumer { get; set; }
        public Services Service { get; set; }

        public Booking(DateTime planedTime, Services service, Costumers costumer)
        {
            PlanedTime = planedTime;
            Service = service;
            Costumer = costumer;
        }
        public override string ToString()
        {
            return
                $"Tid:{PlanedTime: yyyy/MM/dd HH:mm} " +
                $"Tjänst: {Service} " +
                $"Kund: {Costumer} ";
        }
    }
}
