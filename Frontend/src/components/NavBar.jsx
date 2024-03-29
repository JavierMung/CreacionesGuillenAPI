import { Link } from "react-router-dom";
import { CONSTANTS } from "../helpers/Data.js";

function NavBar() {
    return (<>
        <nav className="navbar navbar-expand-lg navbar-light bg-light fixed-top">
            <div className="container-fluid">
                <Link className="navbar-brand" to={'/'}>{CONSTANTS[0].NOMBRE_EMPREASA}</Link>
                <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span className="navbar-toggler-icon"></span>
                </button>
                <div className="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul className="navbar-nav me-auto mb-2 mb-lg-0">
                        <li className="nav-item">
                            <Link className={'nav-link'} to={'/crear-pedido'}>Crear pedido</Link>
                        </li>
                        <li className="nav-item">
                            <Link className={'nav-link'} to={'/inventario'}>Inventario</Link>
                        </li>
                        <li className="nav-item">
                            <Link className={'nav-link'} to={'/pedidos'}>Pedidos</Link>
                        </li>
                        <li className="nav-item">
                            <Link className={'nav-link'} to={'/pedido-rapido'}>Pedido rápido</Link>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
    </>);
}

export default NavBar;