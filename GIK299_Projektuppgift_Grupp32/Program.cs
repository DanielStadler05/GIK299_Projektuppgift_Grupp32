namespace GIK299_Projektuppgift_Grupp32
{
    public class Booking
    {
        public DateTime PlanedTime { get; set; }
        public Costumers Costumer { get; set; }
        public Services Service { get; set; }

        public override string ToString()
        {
            return
                "*** Bokning Bekräftad! ***\n" +
                $"Tid: {PlanedTime: yyyy/MM/dd/hh}" +
                $"Tjänst: {Service}" +
                $"Reg.Nr {Costumer}";
        }
    }
}