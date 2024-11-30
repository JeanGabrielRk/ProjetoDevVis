import React, { useEffect, useState } from 'react';
import { Planta } from '../Interface/Planta';

const ListaPlanta: React.FC = () => {
    const [planta, setPlanta] = useState<Planta[]>([]);

    useEffect(() => {
        fetch('http://localhost:5022/api/tipos/deletar')
            .then(response => {
                if (!response.ok) {
                    throw new Error('Erro na requisição: ' + response.statusText);
                }
                return response.json();
            })
            .then(data => {
                setPlanta(data);
            })
            .catch(error => {
                console.error('Erro:', error);
            });
    }, []);

    const excluirPlanta = (id: number) => {
        fetch(`http://localhost:5022/api/tipos/deletar/${id}`, {
            method: 'DELETE',
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error('Erro ao excluir planta: ' + response.statusText);
                }
                setPlanta(planta.filter(p => p.id !== id));
            })
            .catch(error => {
                console.error('Erro ao excluir planta:', error);
            });
    };

    return (
        <div>
            <h1>Lista de Plantas</h1>
            <table>
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Nome</th>
                        <th>Descrição</th>
                        <th>Criado Em</th>
                        <th>Ações</th>
                    </tr>
                </thead>
                <tbody>
                    {planta.map(planta => (
                        <tr key={planta.id}>
                            <td>{planta.id}</td>
                            <td>{planta.nome}</td>
                            <td>{planta.descricao}</td>
                            <td>{new Date(planta.criadoEm).toLocaleDateString()}</td>
                            <td>
                                <button onClick={() => excluirPlanta(planta.id)}>Excluir</button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
};

export default ListaPlanta;