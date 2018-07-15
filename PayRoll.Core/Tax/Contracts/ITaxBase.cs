namespace PayRoll.Core.Tax
{
    public interface ITaxBase
    {
        int RuleID { get; set; }
        uint Calculate(uint amount);
    }
}