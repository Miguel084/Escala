import {useEffect, useState} from 'react';
import {Button, Form, Modal} from 'react-bootstrap';

export default function ModalForm({ show, handleClose, handleShow, collaborator, setCollaborator, daysOff, setDaysOff, monthYear, setMonthYear }) {
    const [funcionarios, setFuncionarios] = useState([]);

    useEffect(() => {
        async function getFuncionarios() {
            const response = await fetch('https://localhost:7246/api/funcionarios');
            const data = await response.json();
            setFuncionarios(data);
        }

        getFuncionarios();
    }, []);

    const handleCollaboratorChange = (event) => {
        setCollaborator(event.target.value);
    };

    const handleDaysOffChange = (event) => {
        setDaysOff(event.target.value);
    };

    const handleMonthYearChange = (event) => {
        setMonthYear(event.target.value);
    };

    return (
        <Modal show={show} onHide={handleClose}>
            <Modal.Header closeButton>
                <Modal.Title>Cadastro</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <p>Formulário de cadastro de escala 5x2 Fixa</p>

                <Form>
                    <Form.Group controlId="formCollaborator">
                        <Form.Label>Colaboradores</Form.Label>
                        <Form.Control as="select" value={collaborator} onChange={handleCollaboratorChange}>
                            {funcionarios.map(funcionario => (
                                <option key={funcionario.id} value={funcionario.id}>
                                    {funcionario.name}
                                </option>
                            ))}
                        </Form.Control>
                    </Form.Group>

                    <Form.Group controlId="formDaysOff">
                        <Form.Label>Quantidade de Folgas</Form.Label>
                        <Form.Control as="select" value={daysOff} onChange={handleDaysOffChange}>
                            <option>7</option>
                            <option>8</option>
                            <option>9</option>
                            <option>10</option>
                            <option>11</option>
                            <option>12</option>
                            <option>13</option>
                        </Form.Control>
                    </Form.Group>

                    <Form.Group controlId="formMonthYear">
                        <Form.Label>Mês e Ano</Form.Label>
                        <Form.Control type="month" value={monthYear} onChange={handleMonthYearChange} />
                    </Form.Group>
                </Form>

            </Modal.Body>
            <Modal.Footer>
                <Button variant="secondary" onClick={handleClose}>
                    Fechar
                </Button>
                <Button variant="primary" onClick={handleClose}>
                    Salvar
                </Button>
            </Modal.Footer>
        </Modal>
    );
}