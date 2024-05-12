public class Solution
{
    public static Dictionary<string, int> AverageAgeForEachCompany(List<Employee> employees)
    {
        var result = new Dictionary<string, int>();
        foreach (var company in employees.Select(x => x.Company).Distinct().OrderBy(x=>x))
        {
            var age = (int)Math.Round(employees.Where(m => m.Company == company).Average(x => x.Age));
            result.Add(company, age);
        }
        return result;
    }

    public static Dictionary<string, int> CountOfEmployeesForEachCompany(List<Employee> employees)
    {
        var result = new Dictionary<string, int>();

        foreach(var company in employees.Select(x => x.Company).Distinct().OrderBy(x => x))
        {
            int count = employees.Where(m => m.Company == company).Count();
            result.Add(company, count);
        }
        return result;
    }

    public static Dictionary<string, Employee> OldestAgeForEachCompany(List<Employee> employees)
    {
        var result = new Dictionary<string, Employee>();
        foreach(var company in employees.Select(m=>m.Company).Distinct().OrderBy(m=>m))
        {
            Employee employee = employees.OrderByDescending(x => x.Age).First();
            result.Add(company, employee);
        }
        return result;
    }
    public static void Main(string[] args)
    {
        int countOfEmployees = int.Parse(Console.ReadLine());

        var employees = new List<Employee>();

        for (int i = 0; i < countOfEmployees; i++)
        {
            string str = Console.ReadLine();
            string[] strArr = str.Split(' ');
            employees.Add(new Employee
            {
                FirstName = strArr[0],
                LastName = strArr[1],
                Company = strArr[2],
                Age = int.Parse(strArr[3])
            });
        }

        foreach (var emp in AverageAgeForEachCompany(employees))
        {
            Console.WriteLine($"The average age for company {emp.Key} is {emp.Value}");
        }

        foreach (var emp in CountOfEmployeesForEachCompany(employees))
        {
            Console.WriteLine($"The count of employees for company {emp.Key} is {emp.Value}");
        }

        foreach (var emp in OldestAgeForEachCompany(employees))
        {
            Console.WriteLine($"The oldest employee of company {emp.Key} is {emp.Value.FirstName} {emp.Value.LastName} having age {emp.Value.Age}");
        }
    }

}

public class Employee
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string Company { get; set; }
}