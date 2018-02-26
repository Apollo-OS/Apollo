# Apollo
The all new operating system made in C# using Cosmos and the AIC Framework  

Because Apollo uses the AIC Framework, Apollo now includes the AIC Framework as a submodule, existing in the separate AIC Framework repository.  
You can access this repository at https://github.com/Apollo-OS/AIC-Framework.  
When cloning Apollo, it is important that you clone the AIC submodule as well. In recent versions of Git, this can be done using:
```
git clone --recursive https://github.com/Apollo-OS/Apollo.git
```
When the AIC Framework repo is updated, the submodule isn't 
automatically updated, so from time to time, it's a good idea to run the 
following:  

```
git submodule update --remote --merge
```  
Provided you are running a recent version of Git.  
