using System;

namespace Solid
{
    class Program
    {
        static void Main(string[] args)
        {
            PrivateSchool school1 = new PrivateSchool();
            PublicSchool school2 = new PublicSchool();

            //Two schools with the same methods inherited from the parent class (Liskov substitution)

            school1.Name = "St Pauls Secondary";
            school1.Address = "Accra Ghana";
            school1.Income = 450000;
            school1.RemoveCommission();
            school1.ShowInfo();

            Console.WriteLine();

            school2.Name = "Methodist High";
            school2.Address = "Owerri Nigeria";
            school2.Income = 450000;
            school2.AddSponsorship();
            school2.ShowInfo();
        }
    }

    //Base class: all schools can do these
    public class Schools
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public double Income { get; set; }

        public void ShowInfo()
        {
            Console.WriteLine("School Name : " + Name + "\nAddress : " + Address + "\nIncome : " + Income);
        }
    }

    //child class: private schools have to pay commision
    public class PrivateSchool : Schools, IPaysCommission
    {
        public double RemoveCommission()
        {
            //not having to change the value in the parent class
            Income -= 250000;
            return Income;
        }
    }

    //child class: public schools receive sponsorship and can go on strike
    class PublicSchool : Schools, IGetsSponsorship, IGoOnStrike
    {
        public double AddSponsorship()
        {
            Income += 150000;
            return Income;
        }

        public void GoOnStrike()
        {
            Console.WriteLine("On strike!");
        }
    }


    //No class is instantiated in another following dependency inversion


    //Individual interfaces following interface segregation
    public interface IPaysCommission
    {
        public double RemoveCommission();
    }

    public interface IGetsSponsorship
    {
        public double AddSponsorship();
    }

    public interface IGoOnStrike
    {
        public void GoOnStrike();
    }

}
