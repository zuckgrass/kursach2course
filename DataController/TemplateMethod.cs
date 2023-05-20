using System;

public abstract class SportLoadManager
{
    private int trainingSessionCount = 0;
    private int maxTrainingSessionsPerWeek;

    public SportLoadManager(int maxTrainingSessionsPerWeek)
    {
        this.maxTrainingSessionsPerWeek = maxTrainingSessionsPerWeek;
    }

    public void ManageSportLoad()
    {
        if (trainingSessionCount < maxTrainingSessionsPerWeek)
        {
            PerformWarmUp();
            PerformWorkout();
            PerformCoolDown();
            EvaluateSportLoad();
            trainingSessionCount++;
        }
        else
        {
            Console.WriteLine("Maximum training sessions per week exceeded for this level.");
        }
    }

    protected abstract void PerformWarmUp();
    protected abstract void PerformWorkout();
    protected abstract void PerformCoolDown();
    protected abstract void EvaluateSportLoad();

    public int GetTrainingSessionCount()
    {
        return trainingSessionCount;
    }
}

public class BeginnerSportLoadManager : SportLoadManager
{
    public BeginnerSportLoadManager() : base(3)
    {
    }

    protected override void PerformWarmUp()
    {
        Console.WriteLine("Performing light warm-up exercises for beginners.");
    }

    protected override void PerformWorkout()
    {
        Console.WriteLine("Performing low-intensity workout routines for beginners.");
    }

    protected override void PerformCoolDown()
    {
        Console.WriteLine("Performing gentle cool-down exercises for beginners.");
    }

    protected override void EvaluateSportLoad()
    {
        Console.WriteLine("Evaluating sport load for beginners.");
    }
}

public class AmateurSportLoadManager : SportLoadManager
{
    public AmateurSportLoadManager() : base(5)
    {
    }

    protected override void PerformWarmUp()
    {
        Console.WriteLine("Performing moderate warm-up exercises for amateurs.");
    }

    protected override void PerformWorkout()
    {
        Console.WriteLine("Performing medium-intensity workout routines for amateurs.");
    }

    protected override void PerformCoolDown()
    {
        Console.WriteLine("Performing adequate cool-down exercises for amateurs.");
    }

    protected override void EvaluateSportLoad()
    {
        Console.WriteLine("Evaluating sport load for amateurs.");
    }
}

public class AdvancedSportLoadManager : SportLoadManager
{
    public AdvancedSportLoadManager() : base(7)
    {
    }

    protected override void PerformWarmUp()
    {
        Console.WriteLine("Performing intense warm-up exercises for advanced individuals.");
    }

    protected override void PerformWorkout()
    {
        Console.WriteLine("Performing high-intensity workout routines for advanced individuals.");
    }

    protected override void PerformCoolDown()
    {
        Console.WriteLine("Performing thorough cool-down exercises for advanced individuals.");
    }

    protected override void EvaluateSportLoad()
    {
        Console.WriteLine("Evaluating sport load for advanced individuals.");
    }
}