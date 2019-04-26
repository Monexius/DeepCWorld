using static DeepSeaWorldApp.DBClasses.DBs;

namespace DeepSeaWorldApp.ViewModels
{
    public class ExhibitsViewModel : BaseViewModel
    {
        public Exhibition Exhibition { get; }

        public ExhibitsViewModel()
        {
            Exhibition = new Exhibition
            {
                Exhibition_Name = "name",
            };
        }
        public ExhibitsViewModel(Exhibition ex)
        {
            Exhibition = new Exhibition
            {
                Exhibition_ID = ex.Exhibition_ID,
                Exhibition_IMG = ex.Exhibition_IMG,
                Exhibition_Name = ex.Exhibition_Name,
                Exhibition_Video = ex.Exhibition_Video,
                Exhibition_IMG_Name = ex.Exhibition_IMG_Name,
                Exhibition_Video_Name = ex.Exhibition_Video_Name,
                Exhibition_QRCode_Pos = ex.Exhibition_QRCode_Pos,
                Exhibition_Description = ex.Exhibition_Description,
                QRCodes_Name = ex.QRCodes_Name
            };
        }

    }

}