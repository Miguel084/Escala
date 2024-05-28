import {useEffect, useState} from 'react';
import './App.css';
import Header from "../Components/Header/Header.jsx";
import 'bootstrap/dist/css/bootstrap.min.css';
import ModalForm from "../Components/ModalForm/ModalForm.jsx";
import {Button} from "react-bootstrap";

export default function App() {
    const [show, setShow] = useState(false);
    const [collaborator, setCollaborator] = useState("");
    const [daysOff, setDaysOff] = useState("");
    const [monthYear, setMonthYear] = useState("");

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);
    const [funcionarios, setFuncionarios] = useState([]);
    
    
    useEffect(() => {
        async function getFuncionarios() {
            const response = await fetch('https://localhost:7246/api/funcionarios');
            const data = await response.json();
            setFuncionarios(data);
        }

        getFuncionarios();
    });
    
    
    return (
        <>
            <Header />
            <p>Escala 5x2 Fixa</p>
            <Button variant="primary" onClick={handleShow}>
                Fazer uma nova Escala
            </Button>

            <ModalForm
                show={show}
                handleClose={handleClose}
                handleShow={handleShow}
                collaborator={collaborator}
                setCollaborator={setCollaborator}
                daysOff={daysOff}
                setDaysOff={setDaysOff}
                monthYear={monthYear}
                setMonthYear={setMonthYear}
            />
        </>
    );
}