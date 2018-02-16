using System;

public class Cat
{
    public string Breed { get; set; }
    public string Name { get; set; }
    public string SpecialValue { get; set; }

    public Cat(string breed, string name, string specialValue)
    {
        this.Name = name;
        this.Breed = breed;
        this.SpecialValue = specialValue;
    }


    public override string ToString()
    {
        if (this.Breed == "Cymric")
        {
            double furSize = double.Parse(this.SpecialValue);

            return $"{this.Breed} {this.Name} {furSize:f2}";
        }
        else
        {
            return $"{this.Breed} {this.Name} {this.SpecialValue}";
        }
    }
}