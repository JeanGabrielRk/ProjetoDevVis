import React, { useState, useEffect } from 'react';
import { Planta } from '../Interfaces/Planta';


const AlterarPlanta: React.FC = () => {
 
    const id = localStorage.getItem('plantaId'); 
    const [origemId, setOrigemId] = useState<number | ''>('');
    const [tipoId, setTipoId] = useState<number | ''>('');

    
    useEffect(() => {
        if (id) {
            fetch(`http://localhost:5022/api/plantas/${id}`)
                .then(response => response.json())
                .then(data => {
                    setNome(data.nome);
                    setOrigemId(data.origemId);
                    setTipoId(data.tipoId);
                })
                .catch(error => alert('Erro ao carregar dados da planta: ' + error));
        } else {
            alert('ID da planta não encontrado');
        }
    }, [id]);

    const alterarPlanta = (e: React.FormEvent) => {
        e.preventDefault();
        const planta = { nome, origemId: Number(origemId), tipoId: Number(tipoId) };

        if (!id) {
            alert('ID da planta não está disponível');
            return;
        }

        fetch(`http://localhost:5022/api/plantas/${id}`, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(planta),
        })
            .then(response => {
                if (!response.ok) throw new Error('Erro ao alterar planta');
                return response.json();
            })
            .then(() => alert('Planta alterada com sucesso!'))
            .catch(error => alert('Erro: ' + error));
    };

    return (
        <div>
            <h2>Alterar Planta</h2>
            <form onSubmit={alterarPlanta}>
                <div>
                    <label>
                        Nome:
                        <input type="text" value={nome} onChange={e => setNome(e.target.value)} required />
                    </label>
                </div>
                <div>
                    <label>
                        Origem ID:
                        <input
                            type="number"
                            value={origemId}
                            onChange={e => setOrigemId(e.target.valueAsNumber || '')}
                            required
                        />
                    </label>
                </div>
                <div>
                    <label>
                        Tipo ID:
                        <input
                            type="number"
                            value={tipoId}
                            onChange={e => setTipoId(e.target.valueAsNumber || '')}
                            required
                        />
                    </label>
                </div>
                <button type="submit">Alterar</button>
            </form>
        </div>
    );
};

export default AlterarPlanta;
