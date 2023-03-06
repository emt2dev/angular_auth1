##### Angular 14 with ASP.Net Core #####
#### folder structure
# Helpers = validators
# Models = models
# Services = API callls

##### -----------
###    Routes
##### -----------

# to create a component in cli use `ng g c componentName` (ie: ng g c signup)
## go to AngularAuthUI\src\app\app-routing.module.ts and then add the routing to the path
# {path: 'signup', component: SignupComponent}
# go to AngularAuthUI\src\app\app.component.html and delete everything!
# add <router-outlet></router-outlet> then the paths will work
# http://localhost:4200/signup 
# displays AngularAuthUI\src\app\components\signup\signup.component.html

##### -----------
###    Onclick method
##### -----------
### AngularAuthUI\src\app\components\login\login.component.ts
##  implements OnInit
## constructor() { }
## ngOnInit(): void {}
## hideShowPass()

##### -----------
###    Validators/Helpers
##### -----------
#### Ensure the forms have the appropriate responses
#####  AngularAuthUI\src\app\app.module.ts
##### import { ReactiveFormsModule } from '@angular/forms';
# imports: [
# BrowserModule,
# AppRoutingModule,
##### here is the import added---> ReactiveFormsModule
# ],

#### AngularAuthUI\src\app\components\login\login.component.ts
### near the top: import { FormBuilder, FormGroup, Validators } from '@angular/forms';
### loginForm!: FormGroup;
### constructor(private fb: FormBuilder)
#
#  ngOnInit(): void {
#    this.loginForm = this.fb.group({
#      Username: ['', Validators.required],
#      Password: ['', Validators.required]
#    })
#  }
#