import { NumericFormat } from "react-number-format";
import ColumnForm from "../helpers/ColumnForm";
import { productos, clientes } from "../helpers/Data";
function FastoOrder() {
    return (
        <div className="row justify-content-center">
            <h1>Pedido rápido</h1>
            <ColumnForm titulo={"Cliente"} md={9}>
                <select name={"cliente"}  className="form-select" aria-label="Default select example">
                    <option >Seleccionar cliente...</option>
                    {clientes.map((cliente, index) => {
                        return (<>
                            <option key={index} value={cliente.nombre}>{cliente.nombre}</option>
                        </>)
                    })}
                </select>
            </ColumnForm>
            <ColumnForm titulo={"Producto"} md={9}>
                <select name="nombreProducto" className="form-select" aria-label="Default select example" >
                    <option >Seleccionar producto</option>
                    {productos.map((producto, index) => {
                        return (
                            <>
                                <option key={producto.nombre} value={producto.nombre} >
                                    {producto.nombre}
                                </option>

                            </>
                        )
                    })
                    }
                </select>
            </ColumnForm>
            <ColumnForm titulo={"Cantidad"} md={9}>
                    <NumericFormat
                    type="input"
                    suffix=" pzs"
                    thousandSeparator={true}
                    aria-label="Cantidad"
                    className="form-control"
                    >

                    </NumericFormat>
            </ColumnForm>
        </div>
    );
}

export default FastoOrder;