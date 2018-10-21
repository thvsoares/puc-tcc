let curso = function (data) {
    let self = this;
    self.id = ko.observable(data.id);
    self.nome = ko.observable(data.nome);
    self.nomeOriginal = data.nome;

    self.modificado = ko.computed(() => self.nome() !== self.nomeOriginal, this);
    self.undoChanges = () => self.nome(self.nomeOriginal);
}

let model = function() {
    let self = this;
    self.courses = ko.observableArray();

    self.getCourses = () =>  {
        self.courses.removeAll();
        $.get('http://localhost:5000/api/curso')
            .done(data => {
                data.forEach(item => {
                    self.courses.push(new curso(item));
                });
            });
    }
}

let viewModel = new model();
ko.applyBindings(viewModel);
viewModel.getCourses();