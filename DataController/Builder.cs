using System;

// Клас абонементу
class Membership
{
    public bool HasGym { get; set; }
    public bool HasPool { get; set; }
    public bool HasSauna { get; set; }

    public void DisplayMembership()
    {
        Console.WriteLine("Абонемент включає:");
        if (HasGym)
            Console.WriteLine("\t- Спортзал");
        if (HasPool)
            Console.WriteLine("\t- Басейн");
        if (HasSauna)
            Console.WriteLine("\t- Баню");
    }
}

// Будівельник абонементу
interface IMembershipBuilder
{
    void AddGym();
    void AddPool();
    void AddSauna();
    Membership GetMembership();
}

// Реалізація будівельника
class MembershipBuilder : IMembershipBuilder
{
    private Membership membership;

    public MembershipBuilder()
    {
        membership = new Membership();
    }

    public void AddGym()
    {
        membership.HasGym = true;
    }

    public void AddPool()
    {
        membership.HasPool = true;
    }

    public void AddSauna()
    {
        membership.HasSauna = true;
    }

    public Membership GetMembership()
    {
        return membership;
    }
}

// Директор, який керує процесом будівництва абонементу
class MembershipDirector
{
    private IMembershipBuilder membershipBuilder;

    public MembershipDirector(IMembershipBuilder builder)
    {
        membershipBuilder = builder;
    }

    public Membership Construct(bool includeGym, bool includePool, bool includeSauna)
    {
        if (includeGym)
            membershipBuilder.AddGym();
        if (includePool)
            membershipBuilder.AddPool();
        if (includeSauna)
            membershipBuilder.AddSauna();

        return membershipBuilder.GetMembership();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Створення будівельника абонементу
        IMembershipBuilder builder = new MembershipBuilder();
        MembershipDirector director = new MembershipDirector(builder);

        // Побудова абонементу з усіх трьох опцій
        Membership membership1 = director.Construct(true, true, true);
        membership1.DisplayMembership();

        Console.WriteLine();

        // Побудова абонементу з басейном і банею
        Membership membership2 = director.Construct(false, true, true);
        membership2.DisplayMembership();

        Console.WriteLine();

        // Побудова абонементу зі спортзалом
        Membership membership3 = director.Construct(true, false, false);
        membership3.DisplayMembership();
    }
}
