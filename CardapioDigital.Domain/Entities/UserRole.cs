using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardapioDigital.Domain.Entities;

public class UserRole
{
    [Key]
    public Guid UserId { get; private set; }
    public Guid RoleId { get; private set; }
    public DateTime AssignedAt { get; private set; } = DateTime.UtcNow;
    public Guid? AssignedBy { get; private set; }

    private UserRole() { }
    public UserRole(Guid userId, Guid roleId, Guid? assignedBy = null)
    {
        UserId = userId; RoleId = roleId; AssignedBy = assignedBy;
    }
}

