using System;

namespace Backend.Models
{
    public class Notification
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid ReceiverId { get; set; } // ID de l'utilisateur qui reçoit la notification
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsRead { get; set; } = false;

        // Tu peux ajouter une relation avec l'utilisateur plus tard si tu veux
        // public AppUser Receiver { get; set; }
    }
}
