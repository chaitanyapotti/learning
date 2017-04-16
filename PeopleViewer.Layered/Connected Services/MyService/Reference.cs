﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PeopleViewer.Layered.MyService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MyService.IPersonService")]
    public interface IPersonService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPersonService/GetPeople", ReplyAction="http://tempuri.org/IPersonService/GetPeopleResponse")]
        System.Collections.Generic.List<PersonRepository.Interface.Person> GetPeople();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPersonService/GetPeople", ReplyAction="http://tempuri.org/IPersonService/GetPeopleResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<PersonRepository.Interface.Person>> GetPeopleAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPersonService/GetPerson", ReplyAction="http://tempuri.org/IPersonService/GetPersonResponse")]
        PersonRepository.Interface.Person GetPerson(string lastName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPersonService/GetPerson", ReplyAction="http://tempuri.org/IPersonService/GetPersonResponse")]
        System.Threading.Tasks.Task<PersonRepository.Interface.Person> GetPersonAsync(string lastName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPersonService/AddPerson", ReplyAction="http://tempuri.org/IPersonService/AddPersonResponse")]
        void AddPerson(PersonRepository.Interface.Person newPerson);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPersonService/AddPerson", ReplyAction="http://tempuri.org/IPersonService/AddPersonResponse")]
        System.Threading.Tasks.Task AddPersonAsync(PersonRepository.Interface.Person newPerson);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPersonService/UpdatePerson", ReplyAction="http://tempuri.org/IPersonService/UpdatePersonResponse")]
        void UpdatePerson(string lastName, PersonRepository.Interface.Person updatedPerson);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPersonService/UpdatePerson", ReplyAction="http://tempuri.org/IPersonService/UpdatePersonResponse")]
        System.Threading.Tasks.Task UpdatePersonAsync(string lastName, PersonRepository.Interface.Person updatedPerson);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPersonService/DeletePerson", ReplyAction="http://tempuri.org/IPersonService/DeletePersonResponse")]
        void DeletePerson(string lastName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPersonService/DeletePerson", ReplyAction="http://tempuri.org/IPersonService/DeletePersonResponse")]
        System.Threading.Tasks.Task DeletePersonAsync(string lastName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPersonService/UpdatePeople", ReplyAction="http://tempuri.org/IPersonService/UpdatePeopleResponse")]
        void UpdatePeople(System.Collections.Generic.List<PersonRepository.Interface.Person> updatedPeople);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPersonService/UpdatePeople", ReplyAction="http://tempuri.org/IPersonService/UpdatePeopleResponse")]
        System.Threading.Tasks.Task UpdatePeopleAsync(System.Collections.Generic.List<PersonRepository.Interface.Person> updatedPeople);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IPersonServiceChannel : PeopleViewer.Layered.MyService.IPersonService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PersonServiceClient : System.ServiceModel.ClientBase<PeopleViewer.Layered.MyService.IPersonService>, PeopleViewer.Layered.MyService.IPersonService {
        
        public PersonServiceClient() {
        }
        
        public PersonServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PersonServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PersonServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PersonServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Collections.Generic.List<PersonRepository.Interface.Person> GetPeople() {
            return base.Channel.GetPeople();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<PersonRepository.Interface.Person>> GetPeopleAsync() {
            return base.Channel.GetPeopleAsync();
        }
        
        public PersonRepository.Interface.Person GetPerson(string lastName) {
            return base.Channel.GetPerson(lastName);
        }
        
        public System.Threading.Tasks.Task<PersonRepository.Interface.Person> GetPersonAsync(string lastName) {
            return base.Channel.GetPersonAsync(lastName);
        }
        
        public void AddPerson(PersonRepository.Interface.Person newPerson) {
            base.Channel.AddPerson(newPerson);
        }
        
        public System.Threading.Tasks.Task AddPersonAsync(PersonRepository.Interface.Person newPerson) {
            return base.Channel.AddPersonAsync(newPerson);
        }
        
        public void UpdatePerson(string lastName, PersonRepository.Interface.Person updatedPerson) {
            base.Channel.UpdatePerson(lastName, updatedPerson);
        }
        
        public System.Threading.Tasks.Task UpdatePersonAsync(string lastName, PersonRepository.Interface.Person updatedPerson) {
            return base.Channel.UpdatePersonAsync(lastName, updatedPerson);
        }
        
        public void DeletePerson(string lastName) {
            base.Channel.DeletePerson(lastName);
        }
        
        public System.Threading.Tasks.Task DeletePersonAsync(string lastName) {
            return base.Channel.DeletePersonAsync(lastName);
        }
        
        public void UpdatePeople(System.Collections.Generic.List<PersonRepository.Interface.Person> updatedPeople) {
            base.Channel.UpdatePeople(updatedPeople);
        }
        
        public System.Threading.Tasks.Task UpdatePeopleAsync(System.Collections.Generic.List<PersonRepository.Interface.Person> updatedPeople) {
            return base.Channel.UpdatePeopleAsync(updatedPeople);
        }
    }
}
