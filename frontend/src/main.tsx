import { BrowserRouter as Router, Routes, Route } from 'react-router-dom'
import ChatCard from './components/chatcard.tsx'
import App from './App.tsx'
import { createRoot } from 'react-dom/client'
import LoginPage from './components/loginpage.tsx'

createRoot(document.getElementById('root')!).render(
  <Router>
  <Routes>
    <Route path="/" element={<App />} />
    <Route path="/chat" element={<ChatCard />} />
    <Route path="/login" element={<LoginPage />} />
  </Routes>
</Router>
)
