import { Outlet } from "react-router-dom";
import NavBar from "./components/NavBar";
import "./styles/style.css"
//import ReactPDF from '@react-pdf/renderer';
//import Pdf from "./helpers/Pdf";
//import { PDFViewer } from '@react-pdf/renderer';

function App() {
  return (
    <div className="container-fluid" >
      <section className="row">
        <div className="col">
          <NavBar />
        </div>
      </section>
      <div className="row justify-content-center text-center">
        <div className="col mb-5">
          <Outlet />
        </div>
      </div>
    </div>
  );
}

export default App;
