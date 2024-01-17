import Card from "../helpers/Card";
import { productos } from "../helpers/Data";
function Inventario() {
    return (<>
        <h1>Inventario</h1>
        <div className="row">
            {productos.map((producto, index) => {
                return (
                    <>
                        <div className="col-lg-3 col-md-4 col-sm-12">
                            <Card producto={producto} index={index} />
                        </div>
                    </>
                )
            })}

        </div>
    </>);
}

export default Inventario;