import {useState} from "react";
import Header from "../../Components/Header/Header.jsx";
import {Button} from "react-bootstrap";
import ModalForm from "../../Components/ModalForm/ModalForm.jsx";


export default function Home() {
    const [show, setShow] = useState(false);
    const [collaborator, setCollaborator] = useState("");
    const [daysOff, setDaysOff] = useState("");
    const [monthYear, setMonthYear] = useState("");

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    const modalFormProps = {
        show,
        handleClose,
        handleShow,
        collaborator,
        setCollaborator,
        daysOff,
        setDaysOff,
        monthYear,
        setMonthYear
    };

    return (
        <>
            <>
                <Header />
            </>
            <>
                <Button variant="primary" onClick={handleShow}>
                    Cadastrar novo funcionario
                </Button>
            </>
            <a href={"/Locais"}>
                Cadastrar Local
            </a>
            <>
                <ModalForm {...modalFormProps}/>
            </>
        </>
    );
}