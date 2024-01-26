import  Titulo  from "./Titulo.jsx"
function ColumnForm({ children, titulo, lg, md, sm, text="start" }) {
    return (
        <div className={`text-${text} col-lg-${lg} col-md-${md} mt-2`}>
            <Titulo Titulo={titulo} />
            {children}

        </div>
    );
}

export default ColumnForm;