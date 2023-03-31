using System.ComponentModel.DataAnnotations;

namespace OnlineResume.Web.ViewModels;

public class InviteIndexViewModel
{
    [Required(ErrorMessage = "必须填写邀请码")]
    public string Code { get; set; } = string.Empty;
}
