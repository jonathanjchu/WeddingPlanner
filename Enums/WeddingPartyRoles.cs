using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Enums
{
    public enum WeddingPartyRoles
    {
        [Display(Name="Maid of Honor")]
        MaidOfHonor,
        Bridesmaid,
        [Display(Name="Best Man")]
        BestMan,
        Groomsmen,
        [Display(Name="Matron of Honor")]
        MatronOfHonor
    }
}