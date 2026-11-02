namespace GIK299_Projektuppgift_Grupp32
{
    public struct Costumers
    {
        public string Name { get; set; }
        public string Registration { get; set; }
        public string PhoneNumber { get; set; }

        public Costumers(string name, string registration, string phoneNumber)
        {
            Name = name;
            Registration = registration;
            PhoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            return $"{Name}, Reg.Nr {Registration}, Tel: {PhoneNumber}";
        }
    }
}