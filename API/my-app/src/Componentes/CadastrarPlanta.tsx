import React, { useState } from 'react';

const CadastrarPlanta: React.FC = () => {
    const [nome, setNome] = useState('');
    const [origemId, setOrigemId] = useState<number | ''>('');
    const [tipoId, setTipoId] = useState<number | ''>('');

    const cadastrarPlanta = (e: React.FormEvent) => {
        e.preventDefault();
        const planta = { nome, origemId: Number(origemId), tipoId: Number(tipoId) };

        fetch('http://localhost:5022/api/plantas/cadastrar', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(planta),
        })
            .then(response => {
                if (!response.ok) throw new Error('Erro ao cadastrar planta');
                return response.json();
            })
            .then(() => alert('Planta cadastrada com sucesso!'))
            .catch(error => alert('Erro: ' + error));
    };

    return (
        <div>
            <h2>Cadastrar Planta</h2>
            <form onSubmit={cadastrarPlanta}>
                <div>
                    <label>
                        Nome:
                        <input type="text" value={nome} onChange={e => setNome(e.target.value)} required />
                    </label>
                </div>
                <div>
                    <label>
                        Origem ID:
                        <input type="number" value={origemId} onChange={e => setOrigemId(e.target.valueAsNumber || '')} required />
                    </label>
                </div>
                <div>
                    <label>
                        Tipo ID:
                        <input type="number" value={tipoId} onChange={e => setTipoId(e.target.valueAsNumber || '')} required />
                    </label>
                </div>
                <button type="submit">Cadastrar</button>
            </form>
        </div>
    );
};

export default CadastrarPlanta;

