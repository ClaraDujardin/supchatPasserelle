import { useState } from "react";
import { Search } from 'lucide-react';
import fleche from "../assets/fleche.png";
import ProfileCard from "./profilcard";
import UserCard from "./usercard"; // Assure-toi d’avoir ce composant

// Type de données pour un utilisateur
type User = {
  id: number;
  name: string;
  avatarUrl: string;
  hasNotification?: boolean;
};

export default function Sidebar() {
  const [open, setOpen] = useState(true);

  // Liste simulée des utilisateurs
  const [users, setUsers] = useState<User[]>([
    {
      id: 1,
      name: "Alice",
      avatarUrl: "/avatars/alice.jpg",
      hasNotification: true,
    },
    {
      id: 2,
      name: "Bob",
      avatarUrl: "/avatars/bob.jpg",
      hasNotification: false,
    },
    // ajoute autant que tu veux
  ]);

  const handleRemove = (id: number) => {
    setUsers((prev) => prev.filter((u) => u.id !== id));
  };

  return (
    <div className="flex">
      <div className={`${open ? "w-75" : "w-48"} duration-300 p-5 pt-8 h-screen bg-blue-900 relative flex flex-col justify-between`}>
        {/* Bouton pour ouvrir/fermer */}
        <img
          src={fleche}
          alt="fleche-gauche"
          className={`absolute cursor-pointer rounded-full -right-3 top-12 w-7 bg-amber-50 ${!open && "rotate-180"}`}
          onClick={() => setOpen(!open)}
        />

        {/* Barre de recherche */}
        <div className="relative w-full px-3 py-2">
          <input
            type="search"
            placeholder="Rechercher..."
            className="w-full pl-10 pr-4 py-2 rounded-lg bg-gray-100 text-sm text-gray-700 placeholder-gray-400 focus:outline-none focus:ring-2 focus:ring-indigo-500 focus:bg-white transition duration-200"
          />
          <Search className="absolute left-5 top-1/2 transform -translate-y-1/2 text-gray-400 w-4 h-4" />
        </div>

        {/* Liste des utilisateurs */}
        <div className="flex-1 overflow-y-auto mt-4 space-y-3">
          {users.map((user) => (
            <UserCard
              key={user.id}
              name={user.name}
              avatarUrl={user.avatarUrl}
              hasNotification={user.hasNotification}
              onRemove={() => handleRemove(user.id)}
              onClick={() => console.log("Conversation ouverte avec", user.name)}
            />
          ))}
        </div>

        {/* Profil en bas */}
        <div className="mt-auto px-3 py-4">
          <ProfileCard
            name="Mohamed Coulibaly"
            avatarUrl="/avatars/mohamed.jpg"
            isOnline={true}
            onClick={() => console.log("Profil ouvert")}
          />
        </div>
      </div>
    </div>
  );
}
