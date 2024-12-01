import React, { useState } from 'react';
import { Planta } from '../Interfaces/Planta';

const BuscarPlanta: React.FC = () => {
    const [idPlanta, setIdPlanta] = useState('');
    const [planta, setPlanta] = useState<Planta | null>(null);

    const buscarPlanta = () => {
        fetch(`http://localhost:5022/api/plantas/buscar/${idPlanta}`)
            .then(response => {
                if (!response.ok) throw new Error('Planta não encontrada');
                return response.json();
            })
            .then(data => setPlanta(data))
            .catch(error => alert('Erro: ' + error));
    };

    return (
        <div>
            <h2>Buscar Planta</h2>
            <input
                type="text"
                placeholder="ID da planta"
                value={idPlanta}
                onChange={e => setIdPlanta(e.target.value)}
            />
            <button onClick={buscarPlanta}>Buscar</button>
            {planta && (
                <div>
                    <h3>Detalhes da Planta</h3>
                    <p>ID: {planta.idPlanta}</p>
                    <p>Nome: {planta.nome}</p>
                    <p>Origem: {planta.origem?.pais || 'N/A'}</p>
                    <p>Tipo: {planta.tipo?.nome || 'N/A'}</p>
                    <p>Criado Em: {new Date(planta.criadoEm).toLocaleDateString()}</p>
                </div>
            )}
        </div>
    );
};

export default BuscarPlanta;