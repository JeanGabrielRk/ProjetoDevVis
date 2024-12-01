import React, { useState } from 'react';

const ExcluirPlanta: React.FC = () => {
    const [idPlanta, setIdPlanta] = useState('');

    const excluirPlanta = () => {
        fetch(`http://localhost:5022/api/plantas/deletar/${idPlanta}`, { method: 'DELETE' })
            .then(response => {
                if (!response.ok) throw new Error('Erro ao excluir planta');
                alert('Planta excluída com sucesso!');
            })
            .catch(error => alert('Erro: ' + error));
    };

    return (
        <div>
            <h2>Excluir Planta</h2>
            <input
                type="text"
                placeholder="ID da planta"
                value={idPlanta}
                onChange={e => setIdPlanta(e.target.value)}
            />
            <button onClick={excluirPlanta}>Excluir</button>
        </div>
    );
};

export default ExcluirPlanta;