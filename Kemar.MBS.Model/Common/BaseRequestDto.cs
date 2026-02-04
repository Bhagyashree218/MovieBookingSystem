namespace Kemar.MBS.Model.Common
{
    public class BaseRequestDto
    {
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public bool? IsActive { get; set; } //if frontend will control active/inactive status
    }
}
