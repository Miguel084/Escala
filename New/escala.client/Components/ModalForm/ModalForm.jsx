import {useEffect, useState} from 'react';
import {Button, Form, Modal} from 'react-bootstrap';

async function fetchData(url, setData) {
    try {
        const response = await fetch(url);
        const data = await response.json();
        setData(data);
    } catch (error) {
        console.error("Error fetching data: ", error);
    }
}


export default function ModalForm({ show, handleClose, handleShow, collaborator, setCollaborator}) {
    const [funcionarios, setFuncionarios] = useState([]);
    const [locais, setLocais] = useState([]);
    const[gender, setGender] = useState([]);
    
    useEffect(() => {
        fetchData('https://localhost:7213/api/Funcionario/all', setFuncionarios).then(r => console.log(r));
    }, []);

    useEffect(() => {
        fetchData('https://localhost:7213/api/Locais/all', setLocais).then(r => console.log(r));
    }, []);

    const handleCollaboratorChange = (event) => {
        setCollaborator(event.target.value);
    }; 

    const handleGenderChange = (event) => {
        setGender(event.target.value)
    };

    const HandleSubmit = async (event) => {
        event.preventDefault();
        const response = await fetch('https://localhost:7213/api/Funcionario/create', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                name: collaborator,
                gender: gender,
            })
        });
        
    };

    return (
        <Modal show={show} onHide={handleClose}>
            <Modal.Header closeButton>
                <Modal.Title>Cadastro</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <p>Formulário de cadastro de funcionario</p>

                <Form onSubmit={HandleSubmit}>
                    <Form.Group controlId="formCollaborator">
                        <Form.Label>Colaboradores</Form.Label>
                        <Form.Control as="input" type="text" placeholder={'Digite o nome do colaborador'} onChange={handleCollaboratorChange} required={true} />
                    </Form.Group>

                    <Form.Group controlId="formGender">
                        <Form.Label>Genero</Form.Label>
                        <Form.Control as="select" onChange={handleGenderChange} required={true}>
                            <option value={"Masculino"}>Masculino</option>
                            <option value={"Feminino"}>Feminino</option>
                            <option value={"Outro"}>Outro</option>
                        </Form.Control>
                    </Form.Group>
                    
                    <Modal.Footer>
                        <Button variant="secondary" onClick={handleClose}>
                            Fechar
                        </Button>
                        <Button type={"submit"}>
                            Salvar
                        </Button>
                    </Modal.Footer>
                </Form>
            </Modal.Body>
        </Modal>
    );
}