import { useState } from "react";
import { productos, clientes, encargados } from "../helpers/Data";
import Formulario from "../helpers/Formulario";
import useActive from "../hooks/useActive";
function Pedidos() {

    const { active, handleActive } = useActive()
    const [formularios, setFormularios] = useState([]);
    const [selectedProducts, setSelectedProducts] = useState(() => {
        const initialState = {};
        productos.forEach(producto => {
            initialState[producto.nombre] = false;
        });
        return initialState;
    });

    const toggleProductSelection = (nombreProducto) => {
        setSelectedProducts(prevState => {
            console.log(prevState[nombreProducto]);
            if (prevState[nombreProducto]) {
                handleCleanForm(nombreProducto)

            }
            return ({
                ...prevState,
                [nombreProducto]: !prevState[nombreProducto],
            })
        }
        );
    };

    const handleAddFormulario = (producto) => {
        setFormularios(prevFormularios => [
            ...prevFormularios,
            {
                idFormulario: "id" + Math.random().toString(16).slice(2), // Usar un valor único
                idProducto: producto.nombre,
                encargado: '',
                tamaño: '',
                color: '',
                cantidad: 0
            },
        ]);
    };

    const handleCleanForm = (idProducto) => {

        const updatedFormularios = formularios.filter(form => form.idProducto !== idProducto);
        setFormularios(updatedFormularios);

    }

    const MostrarForms = () => {
        console.log(formularios);
    }

    const handleChange = (idFormulario, event) => {
        const updatedFormularios = formularios.map(form => {
            if (form.idFormulario === idFormulario) {
                return { ...form, [event.target.name]: event.target.name === "cantidad" ? parseInt(event.target.value) : event.target.value };
            }
            return form;
        });
        setFormularios(updatedFormularios);
    };

    const handleRemoveFormulario = (idFormulario) => {
        const updatedFormularios = formularios.filter(form => form.idFormulario !== idFormulario);
        setFormularios(updatedFormularios);
    };
    return (
        <>
            <button className="btn btn-success" onClick={MostrarForms}>Mostrar forms</button>
            <h1>Pedidos</h1>
            <div className="row justify-content-center text-center">
                <div className="text-start col-lg-7 col-md-8 mt-2 ">
                    <h3>Cliente</h3>
                </div>
                <div className="col-lg-7 col-md-8 ">
                    <select class="form-select" aria-label="Default select example">
                        <option selected>Seleccionar cliente...</option>
                        {clientes.map((cliente, index) => {
                            return (<>
                                <option value={index}>{cliente.nombre}</option>
                            </>)
                        })}
                    </select>
                </div>
                <div className="text-start col-lg-7 col-md-8 mt-4">
                    <h3>Encargado</h3>
                    <label class="form-check-label me-3" for="flexCheckDefaultactive">
                        Mantener encargado
                    </label>

                    <input class="form-check-input" type="checkbox" onChange={handleActive} value={active} id="flexCheckDefaultactive" />

                </div>
                <div className="col-lg-7 col-md-8">
                    <select class="form-select" aria-label="Default select example" disabled={active}>
                        <option selected>Seleccionar encargado</option>
                        {encargados.map((active, index) => {
                            return (<>
                                <option value={index}>{active.nombre}</option>
                            </>)
                        })}
                    </select>
                </div>
                <div className="text-center col-lg-7 col-md-8 mt-4">
                    <h4>Elige los productos</h4>
                </div>
                <div className="col-lg-7 col-md-8 ">
                    {productos.map((producto) => (
                        <div key={producto.nombre} className="form-check border p-3  m-1">
                            <input
                                className="form-check-input ms-1"
                                type="checkbox"
                                value=""
                                id={"flexCheckDefault" + producto.nombre}
                                checked={selectedProducts[producto.nombre]}
                                onChange={() => toggleProductSelection(producto.nombre)}
                            />
                            <div className="text-start ms-4">
                                <h6 className="form-check-label" htmlFor={"flexCheckDefault" + producto.nombre}>
                                    {producto.nombre}
                                </h6>
                            </div>
                            {selectedProducts[producto.nombre] && (
                                <div className="row">
                                    {formularios.map((formData) => {
                                        if (formData.idProducto === producto.nombre) {
                                            return (
                                                <Formulario
                                                    key={formData.idFormulario}
                                                    active={active}
                                                    producto={producto}
                                                    id={formData.idFormulario}
                                                    formData={formData}
                                                    handleChange={handleChange}
                                                    handleRemove={() => handleRemoveFormulario(formData.idFormulario)}
                                                    showRemoveButton={true}
                                                />
                                            );
                                        }
                                        return null;
                                    })}
                                </div>
                            )}
                            {selectedProducts[producto.nombre] && (
                                <button
                                    style={{ background: "transparent", border: "none" }}
                                    onClick={() => handleAddFormulario(producto)}
                                    className="text-primary link"
                                >
                                    Agregar producto+
                                </button>
                            )}
                        </div>
                    ))}


                    <div className="text-end">
                        <button type="button" class="btn btn-danger ">Cancelar</button>
                        <button type="button" class="btn btn-success ms-2">Realizar pedido</button>
                    </div>
                </div>
            </div>
        </>);
}

export default Pedidos;