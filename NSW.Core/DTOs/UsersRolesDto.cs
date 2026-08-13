namespace NSW.Core.DTOs
{
    public class UserDto
    {
        public string? Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? RoleId { get; set; }
    }

    public class CreateUserDto
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string? RoleId { get; set; }
    }

    public class UpdateUserDto
    {
        public string? Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? RoleId { get; set; }
    }

    public class RoleDto
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
    }

    public class CreateRoleDto
    {
        public string? Name { get; set; }
    }
}
