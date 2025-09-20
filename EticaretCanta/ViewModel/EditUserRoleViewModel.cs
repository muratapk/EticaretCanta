namespace EticaretCanta.ViewModel
{
    public class EditUserRoleViewModel
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string SelectRole { get; set; }
        public List<string> AllRoles { get; set; }  
    }
}
