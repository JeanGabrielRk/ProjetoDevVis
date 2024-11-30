import React, { useEffect, useState } from 'react';
import { Planta } from '../Interface/Planta';

const ListaPlanta: React.FC = () => {
    const [planta, setPlanta] = useState<Planta[]>([]);
    const [nome, setNome] = useState('');
    const [descricao, setDescricao] = useState('');

    useEffect(() => {
        fetch("http://localhost:5022/api/plantas/cadastrar")
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

    const cadastrarPlanta = (e: React.FormEvent) => {
        e.preventDefault(); 
        const novaPlanta = { nome, descricao };

        fetch("http://localhost:5022/api/plantas/cadastrar", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(novaPlanta),
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error('Erro ao cadastrar planta: ' + response.statusText);
                }
                return response.json();
            })
            .then(plantaCadastrada => {
                setPlanta([...planta, plantaCadastrada]);
                setNome(''); 
                setDescricao(''); 
            })
            .catch(error => {
                console.error('Erro ao cadastrar planta:', error);
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
                    </tr>
                </thead>
                <tbody>
                    {planta.map(planta => (
                        <tr key={planta.id}>
                            <td>{planta.id}</td>
                            <td>{planta.nome}</td>
                            <td>{planta.descricao}</td>
                            <td>{new Date(planta.criadoEm).toLocaleDateString()}</td>
                        </tr>
                    ))}
                </tbody>
            </table>

            <h2>Cadastrar Nova Planta</h2>
            <form onSubmit={cadastrarPlanta}>
                <div>
                    <label>
                        Nome:
                        <input
                            type="text"
                            value={nome}
                            onChange={(e) => setNome(e.target.value)}
                            required
                        />
                    </label>
                </div>
                <div>
                    <label>
                        Descrição:
                        <textarea
                            value={descricao}
                            onChange={(e) => setDescricao(e.target.value)}
                            required
                        />
                    </label>
                </div>
                <button type="submit">Cadastrar</button>
            </form>
        </div>
    );
};

export default ListaPlanta;
