import { useEffect, useState } from "react";

async function fetchData(url, setData) {
    try {
        const response = await fetch(url);
        const data = await response.json();
        setData(data);
    } catch (error) {
        console.error("Error fetching data: ", error);
    }
}

export default function Locais() {
    const [locais, setLocais] = useState([]);

    useEffect(() => {
        fetchData('https://localhost:7213/api/Locais/all', setLocais).then(r => console.log(r));
    }, []);

    return (
        <>
            <table className="table">
                <thead>
                <tr>
                    <th scope="col">#</th>
                    <th scope="col">Local</th>
                    <th scope="col">Funcionario(s)</th>
                    <th scope="col">Handle</th>
                </tr>
                </thead>
                <tbody>
                {locais.map((local, index) => (
                    <tr key={index}>
                        <th scope="row">{index + 1}</th>
                        <td>{local.name}</td>
                    </tr>
                    
                ))}
                </tbody>
            </table>
        </>
    );
}
