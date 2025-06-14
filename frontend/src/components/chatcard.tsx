import { useState } from "react";
import { Paperclip, SendHorizonal } from "lucide-react";

export default function ChatCard() {
  const [message, setMessage] = useState("");

  const handleSend = () => {
    if (message.trim()) {
      console.log("Message envoyé :", message);
      setMessage("");
    }
  };

  return (
    <div className="ml-[18rem] mt-16 p-4 max-w-4xl w-full mx-auto">
      <div className="bg-white shadow-md rounded-2xl p-4 flex flex-col h-[75vh] justify-between border">
        {/* Zone de messages */}
        <div className="flex-1 overflow-y-auto mb-4 px-2">
          <p className="text-gray-500 text-sm text-center mt-10">Aucun message pour le moment</p>
        </div>

        {/* Zone d'envoi */}
        <div className="flex items-center gap-2 border-t pt-3">
          <input
            type="text"
            className="flex-1 px-4 py-2 rounded-full border focus:outline-none focus:ring-2 focus:ring-blue-500"
            placeholder="Écris ton message..."
            value={message}
            onChange={(e) => setMessage(e.target.value)}
          />

          <button
            className="p-2 rounded-full hover:bg-gray-200 transition"
            onClick={() => document.getElementById("fileInput")?.click()}
          >
            <Paperclip className="w-5 h-5 text-gray-600" />
          </button>
          <input
            id="fileInput"
            type="file"
            className="hidden"
            onChange={(e) => console.log("Fichier sélectionné :", e.target.files?.[0])}
          />

          <button
            onClick={handleSend}
            className="bg-blue-600 hover:bg-blue-700 text-white px-4 py-2 rounded-full flex items-center gap-1 transition"
          >
            <SendHorizonal className="w-4 h-4" />
            Envoyer
          </button>
        </div>
      </div>
    </div>
  );
}
