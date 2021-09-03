import React, { Component } from 'react';

export class Login extends Component {

  constructor(props) {
    super(props);
        this.state = { username: null, password: null, login:null, loading:null };
        this.DataChanged = this.DataChanged.bind(this);
        this.Login = this.Login.bind(this);
  }

    DataChanged(e) {
        let fields = this.state;
        fields[e.target.name] = e.target.value;
        this.setState({
            fields
        });
    }

    async login(event)
            {
            event.preventDefault();

                let playload = { username: this.state.username, password: this.state.password };
                const url ='localhost:5001/api/ApplicationUser/login';
                const response = await fetch(url, {
                method: 'POST', 
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(playload) 
            });

            const data = await response.json();
            this.setState({ login: data, loading: false });
        }

  

  render() {
    return (
      <div>
        <h1>login screen</h1>
            <form>
                Username
                <input type="text" name="username" onChange={ (e)=> this.DataChanged} />

                    Password
                         <input type="password" name="password" />
                    
                        <input type="submit" name="submit" value="login" onClick={ ()=> this.Login} />
           </form>
       
      </div>
    );
  }
}
