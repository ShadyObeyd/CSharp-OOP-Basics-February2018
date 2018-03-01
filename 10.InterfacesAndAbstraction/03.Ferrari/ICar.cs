public interface ICar
{
    string Model { get; set; }
    string Driver { get; set; }
    string UseBreaks();
    string UseGasPedal();
}