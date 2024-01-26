import ColumnForm from "../helpers/ColumnForm";

function ViewOrders() {
    return (
        <>
            <div className="row justify-content-center">
                <ColumnForm text="center" titulo={"Pedidos"} />
                <ColumnForm lg={8} md={10} >
                    <div className="row">
                        <ColumnForm md={2}>
                            <label className="form-label">Cantidad</label>
                            <input className="form-control me-2" type="search" placeholder="Buscar..." aria-label="Search" />
                        </ColumnForm>
                        <ColumnForm md={2}>
                            <label className="form-label">Cantidad</label>
                            <input className="form-control me-2" type="search" placeholder="Buscar..." aria-label="Search" />
                        </ColumnForm>
                        <ColumnForm md={3}>
                            <label className="form-label">Cantidad</label>
                            <input className="form-control me-2" type="search" placeholder="Buscar..." aria-label="Search" />
                        </ColumnForm>
                        <ColumnForm md={3}>
                            <label className="form-label">Cantidad</label>
                            <input className="form-control me-2" type="search" placeholder="Buscar..." aria-label="Search" />
                        </ColumnForm>
                        <ColumnForm md={2} text="center">
                            <div className="row align-items-center">
                                <div className="col-lg-12">
                                    <button className="btn btn-outline-success" type="submit">Buscar</button>
                                </div>

                            </div>
                        </ColumnForm>
                    </div>

                </ColumnForm>
                <ColumnForm lg={8} md={10} >
                    <table className="table">
                        <thead>
                            <tr>
                                <th scope="col">#</th>
                                <th scope="col">Cliente</th>
                                <th scope="col">Fecha</th>
                                <th scope="col">Cantidad</th>
                                <th scope="col">Status</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <th scope="row">1</th>
                                <td>Mark</td>
                                <td>Otto</td>
                                <td>@mdo</td>
                            </tr>
                            <tr>
                                <th scope="row">2</th>
                                <td>Jacob</td>
                                <td>Thornton</td>
                                <td>@fat</td>
                            </tr>
                            <tr>
                                <th scope="row">3</th>
                                <td colspan="2">Larry the Bird</td>
                                <td>@twitter</td>
                            </tr>
                        </tbody>
                    </table>
                </ColumnForm>
            </div>
        </>
    );
}

export default ViewOrders;