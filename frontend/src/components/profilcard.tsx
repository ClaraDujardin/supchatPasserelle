import React from "react";

type ProfileCardProps = {
  name: string;
  avatarUrl: string;
  isOnline: boolean;
  onClick: () => void;
};

const ProfileCard: React.FC<ProfileCardProps> = ({ name, avatarUrl, isOnline, onClick }) => {
  return (
    <div
      className="flex items-center gap-3 p-3 rounded-lg cursor-pointer hover:bg-blue-800 transition-colors duration-200"
      onClick={onClick}
    >
      <div className="relative">
        <img
          src={avatarUrl}
          alt="avatar"
          className="w-10 h-10 rounded-full object-cover"
        />
        <span
          className={`absolute bottom-0 right-0 w-3 h-3 rounded-full border-2 border-white ${
            isOnline ? "bg-green-500" : "bg-gray-400"
          }`}
        />
      </div>
      <span className="text-white font-medium text-sm truncate">{name}</span>
    </div>
  );
};

export default ProfileCard;
