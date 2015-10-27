<Query Kind="Statements">
  <Connection>
    <ID>b85d0141-156d-4860-8b22-2c9cbc69f417</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>WorkSchedule</Database>
  </Connection>
</Query>

var EmployeeYOECollection = from eachemployee in Employees
select new  {
Name = eachemployee.LastName + " " + eachemployee.FirstName,
YOE = eachemployee.EmployeeSkills.Sum(eachEmployeeSkillrow => eachEmployeeSkillrow.YearsOfExperience)
};
EmployeeYOECollection.Dump();

var MaxYOE = EmployeeYOECollection.Max(eachYOECrow => eachYOECrow.YOE); 

MaxYOE.Dump();

var finallist = from xxx in EmployeeYOECollection 
				where condition
				select name

