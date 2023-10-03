namespace AirLab.Dtos.PurpleAirDatas
{
    public class GetPurpleAirDataDto
    {
        public DateTime TimeStamp { get; set; }
        public double? Humidity { get; set; }
        public double? Temperature { get; set; }
        public double? Pressure { get; set; }
        public double? Pm_1_0 { get; set; }
        public double? Pm_2_5 { get; set; }
        public double? Pm_2_5_alt { get; set; }
        public double? Pm_10_0 { get; set; }
        public double? Um_count_0_3 { get; set; }
        public double? Um_count_0_5 { get; set; }
        public double? Um_count_1_0 { get; set; }
        public double? Pm_1_0_cf_1 { get; set; }
        public double? Pm_1_0_atm { get; set; }
        public double? Pm_2_5_atm { get; set; }
        public double? Pm_2_5_cf_1 { get; set; }
        public double? Pm_2_5_10minute { get; set; }
        public double? Pm_2_5_30minute { get; set; }
        public double? Pm_2_5_60minute { get; set; }
        public double? Pm_2_5_6hour { get; set; }
        public double? Pm_2_5_24hour { get; set; }
        public double? Pm_2_5_1week { get; set; }
    }
}
