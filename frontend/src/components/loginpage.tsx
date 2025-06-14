import  facebook  from "../assets/facebook.png";
import  mails  from "../assets/mails.png";
import { useState } from "react";

export default function LoginPage() {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    alert(`Login with Email: ${email}`);
    // Ici tu peux appeler ton API d'authentification
  };

  const handleFacebookLogin = () => {
    alert("Connexion via Facebook");
    // Intègre ici OAuth Facebook
  };

  const handleGoogleLogin = () => {
    alert("Connexion via Google");
    // Intègre ici OAuth Google
  };

  return (
    <div className="min-h-screen flex items-center justify-center bg-gray-50 px-4">
      <div className="max-w-md w-full bg-white p-8 rounded-xl shadow-md">
        <h2 className="text-3xl font-bold mb-6 text-center text-gray-800">
          Connexion
        </h2>

        <form onSubmit={handleSubmit} className="space-y-6">
          <input
            type="email"
            placeholder="Adresse email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            required
            className="w-full px-4 py-3 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-400"
          />

          <input
            type="password"
            placeholder="Mot de passe"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            required
            className="w-full px-4 py-3 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-400"
          />

          <button
            type="submit"
            className="w-full bg-blue-600 text-white py-3 rounded-md font-semibold hover:bg-blue-700 transition"
          >
            Se connecter
          </button>
        </form>

        <div className="flex items-center my-6">
          <hr className="flex-grow border-gray-300" />
          <span className="mx-4 text-gray-400">ou</span>
          <hr className="flex-grow border-gray-300" />
        </div>

        <div className="flex flex-col space-y-4">
          <button
            onClick={handleFacebookLogin}
            className="flex items-center justify-center space-x-3 border border-blue-700 text-blue-700 py-3 rounded-md font-semibold hover:bg-blue-50 transition"
          >
            <img src={facebook} className="w-5 h-5" />
            <span>Se connecter avec Facebook</span>
          </button>

          <button
            onClick={handleGoogleLogin}
            className="flex items-center justify-center space-x-3 border border-red-600 text-red-600 py-3 rounded-md font-semibold hover:bg-red-50 transition"
          >
            <img src={mails} className="w-5 h-5" />
            <span>Se connecter avec Google</span>
          </button>
        </div>
      </div>
    </div>
  );
}
