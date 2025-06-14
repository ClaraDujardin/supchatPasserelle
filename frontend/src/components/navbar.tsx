import { LogOut, MessageCircle, LayoutDashboard } from "lucide-react";
import { useNavigate } from "react-router-dom";

export default function Navbar({ sidebarOpen }: { sidebarOpen: boolean }) {
  const navigate = useNavigate();

  return (
    <div
      className={`fixed top-4 left-0 right-6 h-16 flex items-center justify-between px-8 bg-white shadow-lg rounded-xl transition-all duration-300 z-50 ${
        sidebarOpen ? 'ml-90' : 'ml-70'
      }`}
    >
      <div className="flex space-x-10 items-center">
        <span className="text-xl font-bold text-gray-800">SupChat</span>
        <nav className="flex space-x-6 text-gray-600">
          <button
            onClick={() => navigate('/workspace')}
            className="hover:text-blue-600 font-medium transition flex items-center gap-1"
          >
            <LayoutDashboard className="w-5 h-5" />
            Workspace
          </button>
          <button
            onClick={() => navigate('/chat')}
            className="hover:text-blue-600 font-medium transition flex items-center gap-1"
          >
            <MessageCircle className="w-5 h-5" />
            Chat
          </button>
        </nav>
      </div>

      <button
        onClick={() => navigate('/logout')}
        className="flex items-center bg-red-100 text-red-600 px-4 py-2 rounded-lg hover:bg-red-200 transition"
      >
        <LogOut className="w-4 h-4 mr-2" />
        Déconnexion
      </button>
    </div>
  );
}
