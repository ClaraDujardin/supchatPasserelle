import Sidebar from "./components/sidebar"
import Navbar from "./components/navbar"
function App() {
  return ( 
    <div>
      <Sidebar/>
      <Navbar sidebarOpen={true}/>
      
    </div>
    
  )
}

export default App
