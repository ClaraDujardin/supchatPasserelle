import { XCircle } from 'lucide-react';

type Props = {
  name: string;
  avatarUrl: string;
  onRemove: () => void;
  hasNotification?: boolean;
  onClick?: () => void; // <--- Ajout ici
};

export default function UserCard({ name, avatarUrl, onRemove, hasNotification, onClick }: Props) {
  return (
    <div
      className="flex items-center justify-between p-2 rounded-lg bg-white hover:bg-gray-100 cursor-pointer shadow transition"
      onClick={onClick} // <-- Ici on rend le tout cliquable
    >
      <div className="flex items-center space-x-3">
        <div className="relative">
          <img src={avatarUrl} alt={name} className="w-10 h-10 rounded-full object-cover" />
          {hasNotification && <span className="absolute top-0 right-0 w-2 h-2 bg-red-500 rounded-full" />}
        </div>
        <span className="font-medium text-gray-800">{name}</span>
      </div>
      <XCircle
        onClick={(e) => {
          e.stopPropagation(); // <-- pour empêcher que le clic sur la croix n'active aussi onClick de la carte
          onRemove();
        }}
        className="text-red-500 w-5 h-5 hover:text-red-700"
      />
    </div>
  );
}
