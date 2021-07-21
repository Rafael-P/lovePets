import { Component } from "react";

export default class Clinicas extends Component{
    constructor(props){
        super(props);
        this.state = {
            listaClinicas : []
        };
    };

    buscarClinicas = () => {
        console.log('Esta função traz todos as clinicas.');

        fetch('http://localhost:5000/api/atendimentos')

        .then(resposta => {
            if (resposta.status !== 200) {
                throw Error();
            };

            return resposta.json();
        })

        .then(resposta => this.setState({ listaClinicas : resposta}))

        .catch(erro => console.log(erro));
    };

    componentDidMount(){
        this.buscarClinicas();
    };

    render(){
        return(

            <div>
                <h1>Gerenciamneto de Clinicas</h1>

                <section>
                    <h2>Lista de Clinicas</h2>

                    <table>

                        <thead>
                            <tr>
                                <th>#</th>
                                <th>Razão Social</th>
                                <th>Cnpj</th>
                                <th>Endereço</th>
                            </tr>
                        </thead>

                        <tbody>

                            {
                                this.state.listaClinicas.map( (clinica) => {
                                    return (
                                        <tr key={clinica.idClinica}>
                                            <td>{clinica.razaoSocial}</td>
                                            <td>{clinica.cnpj}</td>
                                            <td>{clinica.endereco}</td>
                                        </tr>
                                    )
                                })
                            }

                        </tbody>

                    </table>
                </section>
            </div>

        )
    }


}

//export default Clinicas;