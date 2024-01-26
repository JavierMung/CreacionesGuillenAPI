import { useState, useEffect } from "react";
import { clientes, encargados, productos, pedidos } from "../helpers/Data";
import { formatterDolar } from "../helpers/Functions";
import { v4 as uuidv4 } from 'uuid';
import useActive from "../hooks/useActive";
import { NumericFormat } from 'react-number-format';
import SummaryOrder from "./SummaryOrder";
import ColumnForm from "../helpers/ColumnForm";

function CreateOrder() {


    const { active, handleActive } = useActive()
    const [pedido, setPedido] = useState({ cliente: null, productos: [], fechaDeEntrega: null, token: null })
    const [producto, setProducto] = useState({ nombreEncargado: "", nombreProducto: "", cantidad: 0, precio: 0, descripcion: "", numeroProducto: uuidv4() })
    const [listaProductos, setListaProdcutos] = useState([])

    const total = listaProductos && listaProductos.length > 0 ? listaProductos.reduce((accumulator, producto) => {
        return accumulator + (producto.precio * producto.cantidad)
    }, 0) : 0;

    const agregarProducto = () => {
        if (producto.nombreCliente === ""
            || producto.nombreEncargado === ""
            || producto.nombreProducto === ""
            || producto.cantidad <= 0
            || producto.precio <= 0
            || producto.descripcion === ""
        ) alert("Error en la creacion")
        else {

            setListaProdcutos([...listaProductos, producto]);
            setProducto({
                ...producto,
                nombreProducto: "",
                cantidad: 1,
                precio: 0,
                descripcion: "",
                numeroProducto: uuidv4()
            })
        }
    }
    const eliminarProducto = (numeroProductoEliminar) => {
        console.log(numeroProductoEliminar)
        setListaProdcutos((prevListaProductos) => {
            return prevListaProductos.filter(prod => {
                return prod.numeroProducto !== numeroProductoEliminar
            })
        });

    }
    const handleProducto = (event, nombre) => {

        setProducto({
            ...producto,
            [event.target.name]:
                event.target.name === 'precio' || event.target.name === 'cantidad' ?
                    event.target.value.replace(/[^0-9.]/g, '') : event.target.value

        })

    }

    const obtenerFechaActual = () => {
        const fechaActual = new Date();
        const año = fechaActual.getFullYear();
        const mes = (fechaActual.getMonth() + 1).toString().padStart(2, '0');
        const dia = fechaActual.getDate().toString().padStart(2, '0');
        return `${año}-${mes}-${dia}`;
    }
    const handlePedido = (event) => {
        setPedido({ ...pedido, [event.target.name]: event.target.value })
    }
    const validarPedido = () => {
        setPedido({ ...pedido, productos: listaProductos })
    }
    useEffect(() => {
        const enviarPedidoAlServidor = async () => {
            console.log(pedido);
            try {
                const response = await fetch('url_del_servidor', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json',
                    },
                    body: JSON.stringify(pedido),
                });

                if (response.ok) {
                    console.log('Pedido enviado con éxito');
                } else {
                    console.error('Error al enviar el pedido');
                }
            } catch (error) {
                console.error('Error en la petición Fetch:', error);
            }
        };

        if (pedido.productos.length > 0) {
            enviarPedidoAlServidor();
        }
    }, [pedido]);


    return (
        <>
            <h1>Pedido</h1>
            <div className="row justify-content-center text-center p-sm-3 ">

                <ColumnForm titulo={"Cliente"} lg={4} md={6} >
                    <select disabled={listaProductos ? (listaProductos.length > 0) : false} onChange={handlePedido} name={"cliente"} value={pedido.cliente} className="form-select" aria-label="Default select example">
                        <option >Seleccionar cliente...</option>
                        {clientes.map((cliente, index) => {
                            return (<>
                                <option key={index} value={cliente.nombre}>{cliente.nombre}</option>
                            </>)
                        })}
                    </select>
                </ColumnForm>

                <ColumnForm titulo={"Fecha"} lg={2} md={3}>
                    <input onChange={handlePedido} min={obtenerFechaActual()} name="fechaDeEntrega" type="date" aria-label="Last name" className="form-control" placeholder="ejem. azul marino" />
                </ColumnForm>

                <div className="col-12" />

                <ColumnForm lg={6} md={9} titulo={"Encargado"}>
                    <label className="form-check-label me-3" htmlFor="flexCheckDefaultactive">
                        Mantener encargado
                    </label>
                    <input disabled={listaProductos ? (listaProductos.length > 0) : false} className="form-check-input" type="checkbox" onChange={handleActive} value={active} id="" />
                    <select disabled={!active ? (listaProductos.length > 0) : false} onChange={handleProducto} name="nombreEncargado" defaultValue={producto.nombreEncargado} className="form-select" aria-label="Default select example" >
                        <option >Seleccionar encargado</option>
                        {encargados.map((active, index) => {
                            return (<>
                                <option key={index} value={active.nombre}>{active.nombre}</option>
                            </>)
                        })}
                    </select>
                </ColumnForm>
                <div className="col-12" />

                <ColumnForm titulo={"Producto"} lg={6} md={9}>


                    <select onChange={handleProducto} name="nombreProducto" value={producto.nombreProducto} className="form-select" aria-label="Default select example" >
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
                    <div className="row" >

                        <ColumnForm md={3}>
                            <label  className="form-label">Cantidad</label>
                            <NumericFormat
                                onChange={handleProducto}
                                name="cantidad"
                                value={producto.cantidad}
                                displayType={'input'}
                                thousandSeparator={true}
                                aria-label="Cantidad"
                                className="form-control"
                                min={1}
                                suffix=" pzs"
                            />
                        </ColumnForm>
                        <ColumnForm md={4} >
                            <label  className="form-label">Precio</label>
                            <NumericFormat
                                onChange={handleProducto}
                                name="precio"
                                value={producto.precio}
                                displayType={'input'}
                                thousandSeparator={true}
                                prefix={'$'}
                                aria-label="Precio"
                                className="form-control"
                            />
                        </ColumnForm>
                        <ColumnForm md={5}>
                            <label  className="form-label">Descripción</label>
                            <input onChange={handleProducto} name="descripcion" value={producto.descripcion} type="text" aria-label="Last name" className="form-control" placeholder="ejem. azul marino" />
                        </ColumnForm>
                        <ColumnForm text="center" md={12}>
                            <div className="row p-2" >
                                <button onClick={agregarProducto} type="button" className="btn btn-primary ">Agregar producto</button>
                            </div>
                        </ColumnForm>

                    </div>
                </ColumnForm>
                <div className="col-sm-12" />
                <ColumnForm titulo={"Resumen del pedido"} lg={6} md={9} >

                    <SummaryOrder

                        listaProductos={listaProductos}
                        formatterDolar={formatterDolar}
                        eliminarProducto={eliminarProducto}
                        total={total}
                    />

                    <div className="text-end">
                        <button type="button" className="btn btn-danger ">Limpiar</button>
                        <button onClick={validarPedido} type="button" className="btn btn-success ms-2">Realizar pedido</button>
                    </div>
                </ColumnForm>
            </div>
        </>);
}

export default CreateOrder;