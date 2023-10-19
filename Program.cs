using System;

public class StudentKeyListener
{
    public event Action EnterPressed;
    public event Action SpacePressed;
    public event Action EscapePressed;
    public event Action F1Pressed;
    public event Action LeftArrowPressed;
    public event Action RightArrowPressed;
    public event Action UpArrowPressed;
    public event Action DownArrowPressed;

    public void Listen()
    {
        while (true)
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.Enter:
                        EnterPressed?.Invoke();
                        break;
                    case ConsoleKey.Spacebar:
                        SpacePressed?.Invoke();
                        break;
                    case ConsoleKey.Escape:
                        EscapePressed?.Invoke();
                        break;
                    case ConsoleKey.F1:
                        F1Pressed?.Invoke();
                        break;
                    case ConsoleKey.LeftArrow:
                        LeftArrowPressed?.Invoke();
                        break;
                    case ConsoleKey.RightArrow:
                        RightArrowPressed?.Invoke();
                        break;
                    case ConsoleKey.UpArrow:
                        UpArrowPressed?.Invoke();
                        break;
                    case ConsoleKey.DownArrow:
                        DownArrowPressed?.Invoke();
                        break;
                }
            }
        }
    }
}

public class Student
{
    public Student()
    {
        var keyListener = new StudentKeyListener();
        keyListener.EnterPressed += () => Select();
        keyListener.SpacePressed += () => Jump();
        keyListener.EscapePressed += () => OpenRickrollLink();
        keyListener.F1Pressed += () => ShowStudentInfo();
        keyListener.LeftArrowPressed += () => Move("влево");
        keyListener.RightArrowPressed += () => Move("вправо");
        keyListener.UpArrowPressed += () => Move("вверх");
        keyListener.DownArrowPressed += () => Move("вниз");

        keyListener.Listen();
    }

    public void Select()
    {
        Console.WriteLine("Выбран метод выбора (без выбора).");
    }

    public void Jump()
    {
        Console.WriteLine("*звук прыжка Марио*");
    }

    public void OpenRickrollLink()
    {
        try
        {
            string rickrollURL = "https://www.youtube.com/watch?v=dQw4w9WgXcQ";

            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = rickrollURL,
                UseShellExecute = true
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка при открытии ссылки на Рикролл, плакплак: " + ex.Message);
        }
    }



    public void ShowStudentInfo()
    {
        Console.WriteLine("Инфа о бездаре.");
    }

    public void Move(string direction)
    {
        Console.WriteLine($"Идём {direction}.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Student student = new Student();
    }
}
